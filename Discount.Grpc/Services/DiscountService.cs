using AutoMapper;
using Discount.Grpc.Entities;
using Discount.Grpc.Protos;
using Discount.Grpc.Repositories;
using Grpc.Core;

namespace Discount.Grpc.Services;

public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
{
    private readonly IDiscountRepository _discountRepository;
    private readonly IMapper _mapper;

    public DiscountService(IDiscountRepository discountRepository, IMapper mapper)
    {
        _discountRepository = discountRepository ?? throw new ArgumentNullException(nameof(discountRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
    {
        var coupon = await _discountRepository.GetDiscount(request.ProductName);

        if (coupon == null)
        {
            throw new RpcException(new Status(StatusCode.NotFound,
                $"Discount with Product Name equals {request.ProductName} not found."));
        }

        var couponModel = _mapper.Map<CouponModel>(coupon);

        return couponModel;
    }

    public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
    {
        var coupon = _mapper.Map<Coupon>(request);

        await _discountRepository.CreateDiscount(coupon);

        var couponModel = _mapper.Map<CouponModel>(coupon);

        return couponModel;
    }

    public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
    {
        var coupon = _mapper.Map<Coupon>(request);

        await _discountRepository.UpdateDiscount(coupon);

        var couponModel = _mapper.Map<CouponModel>(coupon);

        return couponModel;
    }

    public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
    {
        var deleted = await _discountRepository.DeleteDiscount(request.ProductName);

        var response = new DeleteDiscountResponse()
        {
            Success = deleted
        };

        return response;
    }
}